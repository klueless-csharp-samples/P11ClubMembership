require 'k_log'
require 'k_util'
require 'config/_'
require 'config/app_settings'
require 'config/builder_config'
require 'config/builder_options'
require 'config/copy_resources'
require 'config/project_builder'

require_relative '../.data/project_list'
require_relative '../.data/entity_methods'
require_relative '../.data/entities_all'

option_builder = BuilderOptions
                  .init
                  .debug(1, me: 0, app: 0, projects: 0, entities: 0, config: 0)
                  .copy(1, entity_schema: 0)
                  .create(1, solution: 0, projects: 0, project_builders: 0)

opts = option_builder.build
# Display settings by turning on specific debug flags

option_builder.print                    if opts.debug.me
AppSettings.debug                       if opts.debug.app
ProjectList.current.debug               if opts.debug.projects
KBuilder.configuration.debug            if opts.debug.config

# Copy resources from other locations
CopyResources.init(opts).copy_when_option_is_true

get_entities = EntitiesAll.new
get_entities.debug                          if opts.debug.entities
entities = get_entities.entities
# puts entities.map(&:name)
# log.error 'here'
# log.open_struct AppSettings.current.solution
# log.error 'here'

if opts.create.solution || opts.create.projects || opts.create.project_builders
  log.subheading('Create solution and projects')
  project_builder = ProjectBuilder.current(builder, entities)

  # log.line
  # log.open_struct builder.target_folders.to_h
  # log.line

  project_builder.new_solution          if opts.create.solution
  project_builder.new_projects          if opts.create.projects
  project_builder.new_project_builders  if opts.create.project_builders
end

# npx expo init ClubMembership.ReactNative -t expo-template-bare-typescript

log.warn('DONE')
