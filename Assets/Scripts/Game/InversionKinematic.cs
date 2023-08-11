using UnityEngine;


namespace Game
{
    internal sealed class InversionKinematic : MonoBehaviour
    {
        [SerializeField] private Animator anim;
        [SerializeField] private bool ikActive;
        [SerializeField] private Transform rightHandObj;
        [SerializeField] private Transform leftHandObj;

        private void OnAnimatorIK(int layerIndex)
        {
            if (!anim) return;
            //if the IK is active, set the position and rotation directly to the goal.
            if (ikActive)
            {
                // Set the right hand target position and rotation, if one has been assigned
                if (rightHandObj != null)
                {
                    anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                    anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                    anim.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
                    anim.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);
                }

                if (leftHandObj == null) return;
                anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
                anim.SetIKPosition(AvatarIKGoal.LeftHand, leftHandObj.position);
                anim.SetIKRotation(AvatarIKGoal.LeftHand, leftHandObj.rotation);

            }

            //if the IK is not active, set the position and rotation of the hand and head back to the original position
            else
            {
                anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                anim.SetLookAtWeight(0);
            }
        }

    }
}
