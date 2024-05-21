﻿// Copyright (c) 2015 - 2023 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using Doozy.Editor.UIElements;
using Doozy.Runtime.Reactor.Targets;
using TMPro;
using UnityEditor;

namespace Doozy.Editor.Reactor.Editors.Targets
{
    [CustomEditor(typeof(TextMeshProColorTarget), true)]
    public class TextMeshProColorTargetEditor : ReactorColorTargetEditor
    {
        protected override void InitializeEditor()
        {
            base.InitializeEditor();

            componentHeader
               .SetComponentNameText(ObjectNames.NicifyVariableName(nameof(TextMeshPro)))
               .AddManualButton()
               .AddApiButton("https://api.doozyui.com/api/Doozy.Runtime.Reactor.Targets.TextMeshProColorTarget.html")
               .AddYouTubeButton();

            targetObjectField
                .SetObjectType(typeof(TMP_Text));
        }
    }
}
