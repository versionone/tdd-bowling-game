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
nunit :specs => [:compile] do |t|
  t.command = "..\\core\\lib\\nunit\\bin\\net-2.0\\nunit-console-x86.exe"
  t.assemblies  "./Source/Bowling.Specs/bin/#{@build[:config]}/Bowling.Specs.dll"
  t.options [ " /xml=nunit.results.xml" ]
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
