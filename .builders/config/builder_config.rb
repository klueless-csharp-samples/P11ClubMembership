def builder
  @builder ||= KBuilder::BaseBuilder.init
end

builder_folder    = Dir.getwd
base_folder       = File.expand_path(File.join(builder_folder, '..'))

templates_root    = '~/dev/kgems/k_dsl/_/.template'
definition_root   = '~/dev/kgems/k_dsl/_/.builder-definitions'

KBuilder.configure do |config|
  config.target_folders.add(:data         , base_folder, '.data')
  config.target_folders.add(:root         , base_folder)

  # Builder Definitions
  config.template_folders.add(:definitions, File.join(definition_root, 'csharp-project'))

  # General C#
  config.template_folders.add(:csharp     , File.join(templates_root, 'csharp'))

  # Entity framework
  config.template_folders.add(:csharp_ef  , File.join(templates_root, 'csharp-ef'))
end
