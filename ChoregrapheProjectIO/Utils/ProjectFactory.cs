
using System.Linq;

namespace Baku.Choregraphe
{
    public static class ProjectFactory
    {
        public static ChoregrapheProject CreateProjectWithSingleTimeline(ActuatorList actuatorList)
        {
            var box = new Box(true);
            box.Timeline.ActuatorList = actuatorList;
            box.Timeline.Enable = true;
            //ポイント: サイズをきちんと指定しとかないと終端までモーションが行われない
            box.Timeline.Size = actuatorList.ActuatorCurves.Max(c => c.Keys.Max(k => k.frame));


            var result = new ChoregrapheProject();
            result.RootDiagram.Boxes.Add(box);

            return result;
        }

    }
}
