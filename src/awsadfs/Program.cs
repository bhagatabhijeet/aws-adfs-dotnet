using System;
using System.CommandLine;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace awsadfs
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {

            #region Define root  command
            var rootCommand = new RootCommand("command line tool to ease AWS cli" +
                " authentication against ADFS (multi factor authentication with active directory).");
            #endregion

            #region Define Login subcommand and its options
            var loginSubcommand = new Command("login", "login to aws using adfs");

            var adfsHostOption = new Option<string>("--adfs-host", "your-adfs-hostname");
            var profileOption = new Option<string>("--profile", "your aws profile");
            var authfileOption = new Option<string>("--authfile", "/path/and/file/name");
            #endregion
            //add options to the loginSubcommand
            loginSubcommand.AddOption(adfsHostOption);
            loginSubcommand.AddOption(profileOption);
            loginSubcommand.AddOption(authfileOption); 

            //Add loginSubcommand to rootCommand
            rootCommand.Add(loginSubcommand);





            return await rootCommand.InvokeAsync(args);
        }
                
    }
}