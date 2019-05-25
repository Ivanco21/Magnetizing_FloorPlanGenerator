using System;
using Magnetizing_FPG.Properties;
using Grasshopper.Kernel;


namespace Magnetizing_FPG
{
    public class ValueContainer : GH_Component
    {
        public ValueContainer()
            : base("ValueContainer", "ValueContainer",
              "RoomInstance",
             "Magnetizing_FPG", "Magnetizing_FPG")
        {
        }

        int res;// only link for check
        bool res2;

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("ValueList", "VL", "ValueList", GH_ParamAccess.item);
        }
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {

        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {

            int userListLen = this.Params.Input[0].VolatileData.PathCount;
            for (int i = 0; i < userListLen; i++)
            {
                var roomIDFromNode = this.Params.Input[0].VolatileData.get_Branch(i)[0].ToString();
                bool isIntID = Int32.TryParse(roomIDFromNode, out res);
                if (!isIntID)
                {
                    string outIDMessange = String.Format("Branch: {0} it's not int number?", i);
                    this.AddRuntimeMessage(GH_RuntimeMessageLevel.Error, outIDMessange);
                    break;
                }

                var roomAreaFromNode = this.Params.Input[0].VolatileData.get_Branch(i)[2].ToString();
                bool isRoomAreaInt = Int32.TryParse(roomAreaFromNode, out res);
                if (!isRoomAreaInt)
                {
                    string outRoomAreaMes = String.Format("Branch: {0} it's not int ara?", i);
                    this.AddRuntimeMessage(GH_RuntimeMessageLevel.Error, outRoomAreaMes);
                    break;
                }

                var roomIsEnabled = this.Params.Input[0].VolatileData.get_Branch(i)[3].ToString();
                bool isRoomBool = Boolean.TryParse(roomIsEnabled, out res2);
                if (!isRoomBool)
                {
                    string outMessange = String.Format("Branch: {0} not boolean value?", i);
                    this.AddRuntimeMessage(GH_RuntimeMessageLevel.Error, outMessange);
                    break;
                }
            }



        }
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Resources.ValueListIcon;
            }
        }

        public override Guid ComponentGuid
        {
            get { return new Guid("{b67b6e69-0a37-4da6-8cb9-f0737b8771e2}"); }
        }
    }
}
