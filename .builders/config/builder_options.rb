class BuilderOptions
  class << self
    def init
      BuilderOptions.new
    end
  end

  def initialize
    debug(0)
    copy(0)
    create(0)
  end

  def debug(active, me: 0, app: 0, projects: 0, entities: 0, config: 0)
    active        = active == true || active == 1
    me            = active && (me == true || me == 1)
    app           = active && (app == true || app == 1)
    projects      = active && (projects == true || projects == 1)
    entities      = active && (entities == true || entities == 1)
    config        = active && (config == true || config == 1)

    @debug = {
      active: active,
      me: me,
      app: app,
      projects: projects,
      entities: entities,
      config: config
    }

    self
  end

  def copy(active, entity_schema: 0)
    active        = active == true || active == 1
    entity_schema = active && (entity_schema == true || entity_schema == 1)

    @copy   = { active: active, entity_schema: entity_schema }

    self
  end

  def create(active, solution: 0, projects: 0, project_builders: 0)
    active            = active == true || active == 1
    solution          = active && (solution == true || solution == 1)
    projects          = active && (projects == true || projects == 1)
    project_builders  = active && (project_builders == true || project_builders == 1)

    @create = { 
      active: active,
      solution: solution,
      projects: projects,
      project_builders: project_builders
    }

    self
  end

  def build
    data = {
      debug: @debug,
      copy: @copy,
      create: @create
    }
    KUtil.data.to_open_struct(data)
  end

  def print
    log.open_struct(build)
  end

end