using MateriaLib;
using MelonLoader;
using UnityEngine;

[assembly: MelonInfo(typeof(Orangenium.Main), "Orangenium", "1.0.0", "Circl")]

namespace Orangenium
{
    public class Main : MelonMod
    {
        public override void OnInitializeMelon()
        {
            MateriaLib.Main.SetupMaterial += MakeMetal;
        }

        public static void MakeMetal()
        {
            LibMaterial orange = new LibMaterial("Orangenium", 69420, LibMaterial.MaterialType.metal);
            LibMaterial.NewMaterials.Add(orange);

            MaterialConfig config = new MaterialConfig() { DamageMultiplier = 20f, DurabilityMultiplier = 0.01f};
            orange.Configure(config);

            Material mainMat = UnityEngine.Object.Instantiate(orange.physicalMaterial.materialChannels[0].Material);
            Material nonForgeMat = UnityEngine.Object.Instantiate(orange.physicalMaterial.materialChannels[0].atlasedMaterial);

            mainMat.name = "Orangenium";
            nonForgeMat.name = "Orangenium NonForging";

            orange.ReplaceAllMaterials(new Material[] { mainMat, nonForgeMat }, nonForgeMat);

            mainMat.SetVector("_ColorA", new Vector4(0.631372549f, 0.2f, 0.05490196078f, 1f));
            mainMat.SetVector("_ColorB", new Vector4(1f, 0.3882353f, 0f, 1f));

            nonForgeMat.SetVector("_ColorA", new Vector4(0.631372549f, 0.2f, 0.05490196078f, 1f));
            nonForgeMat.SetVector("_ColorB", new Vector4(1f, 0.3882353f, 0f, 1f));
        }
    }
}
