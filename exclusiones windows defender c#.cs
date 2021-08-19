using System;
using System.Collections.ObjectModel;
using System.Management.Automation;

namespace exclusiones
{
    class Program
    {
        //NOTA es necesario ejecutar el programa como administrador se puede garegar un archivo manifiesto para que 
        //el programa no pueda ejecutarse amenos que den los permisos 
        static void Main(string[] args)
        {
            using (PowerShell PowerShellInst = PowerShell.Create())
            {
                //con esto  guardamos la carpeta donde  estamos ubicados 
                //string path = Directory.GetCurrentDirectory();

                //guardar cualquier carpeta 
                string path = "C:\\Users\\chaca\\Videos\\prueba";
                PowerShellInst.AddScript(@"Add-MpPreference -ExclusionPath '" + path + "'");//excluir una carpeta 
                Collection<PSObject> hola = PowerShellInst.Invoke();

                string path2 = "C:\\Users\\chaca\\Videos\\prueba\\ratonloco.exe";
                PowerShellInst.AddScript(@"Add-MpPreference -ExclusionProcess '" + path2 + "'");//excluir un proceso
                Collection<PSObject> hola1 = PowerShellInst.Invoke();

                PowerShellInst.AddScript(@"Add-MpPreference -ExclusionExtension '" + ".exe" + "'");//excluir un tipo de extencion de archivo
                Collection<PSObject> hola2 = PowerShellInst.Invoke();

            }
        }
    }
}
