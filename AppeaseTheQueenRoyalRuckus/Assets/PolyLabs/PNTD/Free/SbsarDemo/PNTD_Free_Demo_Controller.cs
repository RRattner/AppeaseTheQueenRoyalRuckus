using Adobe.Substance.Runtime;
using UnityEngine;
using PolyLabs.PNTD.Sample;

namespace PolyLabs.PNTD.Examples
{
    public class PNTD_Free_Demo_Controller : MonoBehaviour
    {
        public SubstanceRuntimeGraph cavernousRock;
        
        private float multiplier = 0.0f;
        // Start is called before the first frame update
        private void Start()
        {
            multiplier = 0.0f;
            // Off the start we want to enable the water property on the material,
            // and instead of having to remember the name of the water property, we
            // can add `using PolyLabs.PNTD.Sample` to the top and directly call this
            // by the graph name to get the exact name, in addition to a nice
            // docstring that tells us more about the property and what it does!
            cavernousRock.SetInputBool(cavernous_rock.Enable_Water, true);
            cavernousRock.RenderAsync();
        }
    
        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                UpdateValue(0.1f);
            } else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                UpdateValue(-0.1f);
            }
        }

        private void UpdateValue(float delta)
        {
            multiplier = Mathf.Clamp01(multiplier + delta);
            
            cavernousRock.SetInputFloat(cavernous_rock.Water_Level, multiplier);
            // This will make the edges wetter as the water level rises to give a more natural look.
            cavernousRock.SetInputFloat(cavernous_rock.Water_Edges_Wetness_Distance, multiplier * 0.75f);
            
            // Re-render the substance now that the properties have been changed:
            cavernousRock.RenderAsync();
        }
    }
}

