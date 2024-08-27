using Robust.Shared.Serialization;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom;
using Content.Shared.Damage;
using Content.Shared.DoAfter;

namespace Content.Shared.Stories.EnergyCores;

[RegisterComponent]
[AutoGenerateComponentPause]
public sealed partial class EnergyCoreComponent : Component
{

    [ViewVariables(VVAccess.ReadWrite)]
    public bool Working = true;

    [DataField("onState")]
    public string? OnState = "core_on";

    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public float SecPerMoles = 6;

    [DataField(customTypeSerializer: typeof(TimeOffsetSerializer)), AutoPausedField]
    [ViewVariables(VVAccess.ReadWrite)]
    public TimeSpan NextTick = TimeSpan.Zero;

    [DataField]
    [ViewVariables(VVAccess.ReadWrite)]
    public float TimeOfLife = 600;

    [ViewVariables(VVAccess.ReadWrite)]
    public bool ForceDisabled = false;

    [ViewVariables(VVAccess.ReadWrite)]
    public bool Overheat = false;

    [DataField]
    [ViewVariables(VVAccess.ReadOnly)]
    public EnergyCoreKeyState Requested = EnergyCoreKeyState.None;

    [ViewVariables(VVAccess.ReadOnly)]
    public EnergyCoreKeyState Key = EnergyCoreKeyState.None;

    [DataField(required: true)]
    public DamageSpecifier Damage = default!;

    [DataField]
    public float Heating = 50;

    [DataField]
    public float LifeAfterOverheat = -60;

    [ViewVariables(VVAccess.ReadOnly)]
    public bool Trantransitional = false;

    [DataField]
    public float EnablingLenght = 3.6f;
    [DataField]
    public float DisablingLenght = 1.1f;
}

[Serializable, NetSerializable]
public enum EnergyCoreVisualLayers : byte
{
    IsOn,
    IsOff,
    Enabling,
    Disabling
}

[Serializable, NetSerializable]
public enum EnergyCoreState : byte
{
    Disabled,
    Enabled,
    Disabling,
    Enabling
}
[Serializable, NetSerializable]
public enum EnergyCoreKeyState : byte
{
    None,
    Gold,
    Gray,
    Sindi,
    RnD
}

[Serializable, NetSerializable]
public sealed partial class TogglePowerDoAfterEvent : SimpleDoAfterEvent
{
    public NetEntity? Initer;
    public TogglePowerDoAfterEvent(NetEntity? initer)
    {
        Initer = initer;
    }
}
