using BepInEx;
using UnityEngine;
using System.Collections.Generic;

namespace HS2VR_POV
{
    [BepInPlugin("com.hs2vr.povcycle", "HS2VR POV Cycle", "4.0")]
    public class HS2VR_POVCycle : BaseUnityPlugin
    {
        private bool povMode = false;

        private int currentIndex = 0;
        private List<Transform> characterHeads = new List<Transform>();

        private Transform vrRig;
        private Renderer[] currentHeadRenderers;

        private Vector3 eyeOffset = new Vector3(0f, 1.2f, 0.12f); // 摄像机相对头骨偏移量

        void Update()
        {
            // 自动找VRRig
            if (vrRig == null && Camera.main != null)
                vrRig = Camera.main.transform.parent;

            // 按 X → 进入/退出 POV 模式
            if (Input.GetKeyDown(KeyCode.JoystickButton2))   // X键
            {
                povMode = !povMode;

                if (povMode)
                    EnterPOVMode();
                else
                    ExitPOVMode();
            }

            // 按 A → 在POV模式中切换角色
            if (povMode && Input.GetKeyDown(KeyCode.JoystickButton0)) // A键
            {
                NextCharacterPOV();
            }
        }

        void LateUpdate()
        {
            if (!povMode || vrRig == null) return;
            if (currentIndex < 0 || currentIndex >= characterHeads.Count) return;

            var head = characterHeads[currentIndex];
            if (head == null) return;

            // 每帧实时跟随角色头骨位置
            vrRig.position = head.position + eyeOffset;
        }

        // ======== 主功能 ========

        void EnterPOVMode()
        {
            Logger.LogInfo("Entering POV Mode");

            RefreshCharacterList();

            if (characterHeads.Count == 0)
            {
                Logger.LogWarning("No characters found!");
                povMode = false;
                return;
            }

            currentIndex = 0;
            ApplyPOVToCurrent();
        }

        void ExitPOVMode()
        {
            Logger.LogInfo("Exiting POV Mode");

            RestoreHeadRenderers();
            characterHeads.Clear();
        }

        void NextCharacterPOV()
        {
            RestoreHeadRenderers(); // 恢复上一个头

            currentIndex++;
            if (currentIndex >= characterHeads.Count)
                currentIndex = 0;

            ApplyPOVToCurrent();
        }

        // ======== 工具函数 ========

        void RefreshCharacterList()
        {
            characterHeads.Clear();

            // 搜索所有“cf_J_Head”
            var heads = GameObject.FindObjectsOfType<Transform>();
            foreach (var t in heads)
            {
                if (t.name == "cf_J_Head")
                    characterHeads.Add(t);
            }

            Logger.LogInfo("Characters found: " + characterHeads.Count);
        }

        void ApplyPOVToCurrent()
        {
            var head = characterHeads[currentIndex];
            if (head == null) return;

            currentHeadRenderers = head.GetComponentsInChildren<Renderer>(true);

            // 隐藏当前角色头部（包含头发）
            foreach (var r in currentHeadRenderers)
                if (r != null) r.enabled = false;

            Logger.LogInfo($"Switched POV to character #{currentIndex}");
        }

        void RestoreHeadRenderers()
        {
            if (currentHeadRenderers == null) return;

            foreach (var r in currentHeadRenderers)
                if (r != null) r.enabled = true;

            currentHeadRenderers = null;
        }
    }
}
