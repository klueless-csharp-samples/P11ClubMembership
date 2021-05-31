require 'fileutils'

class CopyResources
  attr_accessor :opts

  class << self
    def init(opts)
      CopyResources.new(opts)
    end
  end

  def initialize(opts)
    @opts = opts
  end

  def copy_when_option_is_true
    copy_entity_schema
  end

  def copy_entity_schema
    return unless opts.copy.entity_schema
      
    source = File.expand_path('~/dev/printspeak/printspeak/_local/club_membership/entities/entities_all.rb')
    destination = File.expand_path('~/dev/csharp/P11ClubMembership/.data/entities_all.rb')
  
    return if unchanged(source, destination)

    FileUtils.mkdir_p(File.dirname(destination))

    copy(source, destination)
  end

  private

  def copy(source, destination)
    FileUtils.cp(source, destination)

    log.info 'Copy file'
    log.kv 'Source', source
    log.kv 'Destination', destination
  end

  def unchanged(source, destination)
    if File.exist?(source) && File.exist?(destination) && FileUtils.compare_file(source, destination)
      log.info "Skip unchanged file: #{source}"
      return true
    end
    false
  end
end
