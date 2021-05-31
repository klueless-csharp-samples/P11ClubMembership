class ProjectBuilder
  attr_accessor :builder
  attr_accessor :builder_config
  attr_accessor :project_list
  attr_accessor :entities

  class << self
    def current(builder, entities)
      @current ||= ProjectBuilder.new(builder, ProjectList.current, entities)
    end
  end

  def initialize(builder, project_list, entities)
    @builder = builder
    @project_list = project_list
    @entities = entities

    update_target_folders
  end

  # ----------------------------------------------------------------------
  # Add new DotNet solution
  # ----------------------------------------------------------------------

  def solution_exists?
    file = "#{AppSettings.current.solution.application}.sln"
    solution_file = File.join(builder.target_folders.get(:root), file)
    puts solution_file

    puts File.exist?(solution_file)
    File.exist?(solution_file)
  end

  def new_solution
    log.section_heading 'New solution'

    if solution_exists?
      log.error('Solution already exists')
      return
    end

    builder.cd(:root).rc('dotnet new sln')
  end

  # ----------------------------------------------------------------------
  # Add new DotNet project
  # ----------------------------------------------------------------------

  def new_projects
    log.section_heading 'New projects'

    project_list.active.each do |project|
      new_project(project)
      attach_to_solution(project)
    end
  end

  def new_project(project)
    builder.cd(project.name)

    file = "#{project.application}.csproj"
    project_file = File.join(builder.target_folder, file)

    if File.exist?(project_file)
      log.error("Project already exists: #{project.application}")
      return
    end

    builder.rc("dotnet new #{project.project_dotnet_type} -n #{project.application} -o .")
  end

  def attach_to_solution(project)
    puts 'xxxxxxxxxxxxxxxxx1'
    return unless solution_exists?

    puts 'xxxxxxxxxxxxxxxxx2'
    builder
      .cd(:root)
      .rc("dotnet sln add #{project.application_lib_path}/#{project.application}.csproj")
  end

  # ----------------------------------------------------------------------
  # Add klueless builder project for DotNet project
  # ----------------------------------------------------------------------

  def new_project_builders
    log.section_heading 'New project builders'

    project_list.active.each do |project|
      new_project_builder(project)
    end
  end

  def new_project_builder(project)
    # log.section_heading project.name
    # log.open_struct(project)

    builder
      .cd("#{project.name}_builder".to_sym)
      .add_file('config/_.rb'                 , template_file: 'def/_.rb')
      .add_file('config/builder_config.rb'    , template_file: 'def/builder_config.rb',
        solution: AppSettings.current.solution,
        project: project
      )
      .add_file('config/builder_options.rb'   , template_file: 'def/builder_options.rb')
      .add_file('config/project_setup.rb'     , template_file: 'def/project_setup.rb',
        solution: AppSettings.current.solution,
        project: project
      )
      .add_file('config/ef_migration.rb'      , template_file: 'def/ef_migration.rb',
        solution: AppSettings.current.solution,
        project: project
      )
      .add_file('config/project_code.rb'      , template_file: 'def/project_code.rb',
        solution: AppSettings.current.solution,
        project: project
      )
      .add_file('setup.rb'                    , template_file: 'def/setup.rb',
        solution: AppSettings.current.solution,
        project: project
      )
  end

  private

  def update_target_folders
    # root = @builder_config.target_folders.get(:root)
    project_list.active.each do |project|
      @builder.target_folders.add(project.name, :root, project.application_lib_path)
      @builder.target_folders.add("#{project.name}_builder".to_sym, :root, project.application_lib_path, '.builders')
    end
  rescue => exception
    binding.pry
  end
end