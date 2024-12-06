using CharacterCreator.Models;
using System.Runtime.Intrinsics.X86;
using System;
using CharacterCreator.Data;

namespace CelesteMountain.Data
{
    public class SeedData

    {
        public static void Seed(CharacterCreatorContext context)
        {
            if (!context.Characters.Any())  // this is to prevent adding duplicate data
            {
                

            }

        }

    }

}

