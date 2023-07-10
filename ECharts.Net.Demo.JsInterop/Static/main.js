import { dotnet } from './dotnet.js'

const is_browser = typeof window != "undefined";
if (!is_browser) throw new Error(`Expected to be running in a browser`);

const { getAssemblyExports, getConfig } = 
  await dotnet.create();

const config = getConfig();
const interop = await getAssemblyExports(config.mainAssemblyName);
console.log(config.mainAssemblyName);
await dotnet.run();

window.interop = interop[config.mainAssemblyName.slice(0, -4)];