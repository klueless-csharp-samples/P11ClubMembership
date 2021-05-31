include KLog::Logging

Handlebars::Helpers.configure do |config|
  config_file = File.join(Gem.loaded_specs['handlebars-helpers'].full_gem_path, '.handlebars_helpers.json')
  config.helper_config_file = config_file
end

def camel
  require 'handlebars/helpers/string_formatting/camel'
  Handlebars::Helpers::StringFormatting::Camel.new
end

def titleize
  require 'handlebars/helpers/string_formatting/titleize'
  Handlebars::Helpers::StringFormatting::Titleize.new
end

def pluralize
  require 'handlebars/helpers/inflection/pluralize'
  Handlebars::Helpers::Inflection::Pluralize.new
end

# require 'config/app_settings'
# require 'app_settings.rb'
# require 'models.rb'

# def opts
#   OpenStruct.new(
#     support_mssql: true,
#     support_pgsql: false,
#     app: app_settings#,
#     # entities: entities
#   )
# end
