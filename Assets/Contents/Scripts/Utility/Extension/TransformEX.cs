using UnityEngine;

namespace Utility.Extension
{
    public static class TransformEX
    {
        /// <summary>
        /// 実際のスケールであるlossyScaleを設定します
        /// </summary>
        /// <param name="self"></param>
        /// <param name="lossyScale"></param>
        public static void SetLossyScale(this Transform self, Vector3 lossyScale)
        {
            if (self.parent == null)
            {
                self.localScale = lossyScale;
            }
            else
            {
                lossyScale.x /= self.parent.lossyScale.x;
                lossyScale.y /= self.parent.lossyScale.y;
                lossyScale.z /= self.parent.lossyScale.z;
                self.localScale = lossyScale;
            }
        }
    }
}