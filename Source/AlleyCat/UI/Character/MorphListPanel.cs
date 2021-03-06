using System.Linq;
using AlleyCat.Autowire;
using AlleyCat.Character.Morph;
using Godot;
using JetBrains.Annotations;

namespace AlleyCat.UI.Character
{
    [Singleton(typeof(MorphListPanel))]
    public class MorphListPanel : Panel
    {
        [Service]
        public IMorphableCharacter Character { get; private set; }

        [Node]
        protected TabContainer TabContainer { get; private set; }

        [Export, UsedImplicitly] private PackedScene _groupPanelScene;

        [PostConstruct]
        protected virtual void OnInitialized()
        {
            LoadMorphs(Character.Morphs);
        }

        protected virtual void LoadMorphs(IMorphSet morphSet)
        {
            var index = 0;

            foreach (var group in morphSet.Groups)
            {
                var tab = (MorphGroupPanel) _groupPanelScene.Instance();

                tab.LoadGroup(group, morphSet.Values.Where(m => m.Definition.Group == group));

                TabContainer.AddChild(tab);
                TabContainer.SetTabTitle(index, group.DisplayName);

                index++;
            }
        }

        public override void _Ready()
        {
            base._Ready();

            this.Autowire();
        }
    }
}
