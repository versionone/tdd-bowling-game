require 'rake'
require 'albacore'
require_relative 'build_config.rb'

task :default => :compile

desc "Compiles the solution."
msbuild :compile => :assemblyinfo do |msb|
  msbuild_extensions = File.join(File.dirname(__FILE__), "Libraries", "msbuild")
  msb.properties(
    :configuration => @build[:config],
    :MSBuildExtensionsPath32 => msbuild_extensions
  )
  msb.targets :Clean, :Rebuild
  msb.solution = @build[:solution]
end

desc "Runs specifications."
exec :specs => :compile do |gallio|
  gallio.command = @build[:gallio]
  gallio.parameters(
    "./Source/Bowling.Specs/bin/#{@build[:config]}/Bowling.Specs.dll",
    '/report-name-format:specifications',
    '/report-type:XML')
end

assemblyinfo :assemblyinfo  do |asm|
  asm.version = "#{@build[:version]}"
  asm.description = @build[:config].to_s
  asm.product_name = "TDD Bowling Game"
  asm.copyright = "Copyright #{Time.now.year} VersionOne, Inc."
  
  asm.output_file = "Source/Bowling.Specs/AssemblyInfoCommon.cs"
end

desc "launch the code in VisualStudio"
task :sln do
  Thread.new do
    solution = @build[:solution]
    system %{start "" "#{solution}"}
  end
end
