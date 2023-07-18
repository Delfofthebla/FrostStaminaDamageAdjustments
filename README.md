# FrostStaminaDamageAdjustments

A Synthesis patcher for Skyrim that can reduce (or increase) stamina damage from frost spells and other similar detrimental effects that have it as secondary actor value.

### This is a hard fork of FrostSpellsNoStaminaDamage

I didn't like the idea of just removing stamina damage altogether since that was, you know, the entire point of frost spells. I recognize that they can also slow, but still. I made this fork to just reduce it instead of outright removing it, and have enjoyed the balance that that brings.

### Justification

When running a combat setup where the player and/or NPCs require stamina to attack, frost spells dealing stamina damage can be quite OP (and annoying). A simple frostbite will prevent the target from ever attacking. This patcher remedies that by allowing you to reduce the stamina damage from all relevant magic effects (or remove it completely).

Settings allow the user to provide a list of mod names and EditorIDs to ignore. Mod name is matched against the mod where the record was first introduced (i.e., skyrim.esm would ignore all spells from the original vanilla game, but not those added in DLCs).
