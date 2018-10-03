﻿using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace PumpEditor
{
    public class PrefabVariantTreeView : TreeView
    {
        private const float SpaceBeforeIconAndLabel = 18.0f;
        private const float AssetIconWidth = 16.0f;

        private static Texture2D PrefabIcon = EditorGUIUtility.FindTexture("prefab icon");
        private static Texture2D PrefabVariantIcon = EditorGUIUtility.FindTexture("prefabvariant icon");

        private TreeViewItem root;

        public PrefabVariantTreeView(TreeViewState treeViewState, TreeViewItem root)
        : base(treeViewState)
        {
            this.root = root;
            extraSpaceBeforeIconAndLabel = SpaceBeforeIconAndLabel;
            Reload();
        }

        protected override TreeViewItem BuildRoot()
        {
            SetupDepthsFromParentsAndChildren(root);

            return root;
        }

        protected override bool CanMultiSelect(TreeViewItem item)
        {
            return false;
        }

        protected override void RowGUI(RowGUIArgs args)
        {
            var assetIconRect = args.rowRect;
            assetIconRect.x += GetContentIndent(args.item);
            assetIconRect.width = AssetIconWidth;

            var instanceId = args.item.id;
            var assetPath = AssetDatabase.GetAssetPath(instanceId);
            var asset = AssetDatabase.LoadAssetAtPath<Object>(assetPath);
            var isVariant = PrefabUtility.GetPrefabAssetType(asset) == PrefabAssetType.Variant;

            var assetIconTexture = isVariant ? PrefabVariantIcon : PrefabIcon;
            GUI.DrawTexture(assetIconRect, assetIconTexture);

            base.RowGUI(args);
        }
    }
}
