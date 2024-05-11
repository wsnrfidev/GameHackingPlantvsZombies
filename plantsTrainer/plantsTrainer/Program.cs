using ImGuiNET;
using ClickableTransparentOverlay;
using Swed32;




namespace PlantsTrainer
{
    public class Program : Overlay
    {
        bool unlimitedSuns = false;
        IntPtr moduleBase;
        int sunAddress = 0x1E846;


        Swed swed = new Swed("PlantsVsZombies");

        protected override void Render()
        {
            ImGui.Begin("Plants Hack");
            ImGui.Checkbox("Matahari Anti Habis", ref unlimitedSuns);
            ImGui.End();
        }

        public void HackLogic()
        {

            moduleBase = swed.GetModuleBase(".exe");

            while (true)
            {
                if (unlimitedSuns)
                {
                    swed.WriteBytes(moduleBase, sunAddress, "90 90 90 90 90 90");
                }
                else
                {
                    swed.WriteBytes(moduleBase, sunAddress, "89 B7 78 55 00 00");
                }
            }   
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Memulai Hacking...");
            Program program = new Program();
            program.Start().Wait();
            Thread hackThread = new Thread(program.HackLogic) { IsBackground = true };
            hackThread.Start();
        }
    }
}
