using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{
    public abstract class CollisionEnterFrame : MonoBehaviour
    {
        [SerializeField, LabelName("충돌 대상 레이어")]
        private LayerMask targetLayer;

        public void OnCollisionEnter(Collision collision)
        {
            // 충돌체의 레이어가 타겟 레이어 중 하나일 경우 true 반환 (비트 연산 적용) 
            bool isTargetLayer =
            (
                LayerMask.GetMask(LayerMask.LayerToName(collision.gameObject.layer)) & targetLayer
            ) != 0;
            if (isTargetLayer) CollisionEnter(collision);
        }

        protected abstract void CollisionEnter(Collision collision);
    }

    public abstract class CollisionStayFrame : MonoBehaviour
    {
        [SerializeField, LabelName("충돌 대상 레이어")]
        private LayerMask targetLayer;

        public void OnCollisionStay(Collision collision)
        {
            // 충돌체의 레이어가 타겟 레이어 중 하나일 경우 true 반환 (비트 연산 적용)
            bool isTargetLayer =
            (
                LayerMask.GetMask(LayerMask.LayerToName(collision.gameObject.layer)) & targetLayer
            ) != 0;
            if (isTargetLayer) CollisionStay(collision);
        }

        protected abstract void CollisionStay(Collision collision);
    }

    public abstract class CollisionExitFrame : MonoBehaviour
    {
        [SerializeField, LabelName("충돌 대상 레이어")]
        private LayerMask targetLayer;

        public void OnCollisionExit(Collision collision)
        {
            // 충돌체의 레이어가 타겟 레이어 중 하나일 경우 true 반환 (비트 연산 적용)
            bool isTargetLayer =
            (
                LayerMask.GetMask(LayerMask.LayerToName(collision.gameObject.layer)) & targetLayer
            ) != 0;
            if (isTargetLayer) CollisionExit(collision);
        }

        protected abstract void CollisionExit(Collision collision);
    }

    public abstract class TriggerEnterFrame : MonoBehaviour
    {
        [SerializeField, LabelName("충돌 대상 레이어")]
        private LayerMask targetLayer;

        public void OnTriggerEnter(Collider other)
        {
            // 충돌체의 레이어가 타겟 레이어 중 하나일 경우 true 반환 (비트 연산 적용)
            bool isTargetLayer =
            (
                LayerMask.GetMask(LayerMask.LayerToName(other.gameObject.layer)) & targetLayer
            ) != 0;
            if (isTargetLayer) TriggerEnter(other);
        }

        protected abstract void TriggerEnter(Collider other);
    }

    public abstract class TriggerStayFrame : MonoBehaviour
    {
        [SerializeField, LabelName("충돌 대상 레이어")]
        private LayerMask targetLayer;

        public void OnTriggerStay(Collider other)
        {
            // 충돌체의 레이어가 타겟 레이어 중 하나일 경우 true 반환 (비트 연산 적용)
            bool isTargetLayer =
            (
                LayerMask.GetMask(LayerMask.LayerToName(other.gameObject.layer)) & targetLayer
            ) != 0;
            if (isTargetLayer) TriggerStay(other);
        }

        protected abstract void TriggerStay(Collider other);
    }

    public abstract class TriggerExitFrame : MonoBehaviour
    {
        [SerializeField, LabelName("충돌 대상 레이어")]
        private LayerMask targetLayer;

        public void OnTriggerExit(Collider other)
        {
            // 충돌체의 레이어가 타겟 레이어 중 하나일 경우 true 반환 (비트 연산 적용)
            bool isTargetLayer =
            (
                LayerMask.GetMask(LayerMask.LayerToName(other.gameObject.layer)) & targetLayer
            ) != 0;
            if (isTargetLayer) TriggerExit(other);
        }

        protected abstract void TriggerExit(Collider other);
    }
}