
_Version 1.0.0_

_**AUGURY OVERVIEW**_ 

_A fusion of Old School RuneScape’s open-ended progression, Diablo’s demonic gothic horror, and the deeply unsettling surrealism of LOZ Majora’s Mask._

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

**Premise:**

In Carnom, reality itself teeters on madness as the approach of a cosmic event—the Veilfracture—unravels the barriers between worlds. Nightmarish hallucinations seep into waking life, twisting familiar landscapes into grotesque parodies of themselves. Villagers whisper to unseen entities, cultists dance in hypnotic spirals of blood, and shadows bleed into physical form. Time and sanity erode as the lunar sky fractures into kaleidoscopic chaos, signaling the inevitable awakening of eldritch horrors slumbering beneath reality. You, haunted by visions of past atrocities and driven to near madness, must navigate this psychedelic nightmare, mastering your skills to either halt or succumb to this terrifying convergence.


**Core Gameplay Features**
1. Tick-Based Combat (OSRS-Inspired)
Timed Click Combat: Actions occur in distinct ticks, emphasizing tactical timing and rhythmic precision.


**Combat Styles:** Freely choose and train skills in Melee, Ranged, and Magic, influenced by your character’s skill progression.


2. **Skill-Driven Progression**
Dynamic Skills: Classic RuneScape-style skills including Woodcutting, Mining, Alchemy, alongside dark arts such as Fleshcrafting, Shadowmasonry, and Soulbinding.


**Advanced Content:** Unlock quests and regions by achieving high skill levels or creating unique items, mirroring OSRS’s layered quest system.


3. Surreal Open World
Fluid Exploration: Wander seamlessly across twisted towns, surreal forests, and hallucinatory landscapes, without hard-loading transitions.


**Reality Shifts:** Environmental phenomena caused by the Veilfracture alter perception, summon fleeting phantoms, and distort spatial awareness.


4. Dark, Psychedelic Quests & Narrative
**Quest Complexity:** Early quests accessible with minimal skill, evolving into profound, skill-gated, reality-warping narratives.


**Moral Ambiguity & Surreal Horror:** NPCs blur the line between ally and enemy; moral decisions carry hallucinatory consequences that profoundly impact gameplay.


5. Macabre, Surreal Atmosphere
**Haunting Art & Sound:** Gothic architecture distorted by surreal elements, unsettling soundscapes, and disturbing visual motifs intensify psychological tension.


Cosmic Dread: Constant, unsettling presence reminiscent of Majora’s Mask, deepened by the demonic influences characteristic of Diablo.



**Conclusion**

In Augury, reality frays at the edges as the Veilfracture approaches. Navigate an open world where RuneScape-like progression meets Diablo’s unrelenting gothic horror, woven through with the unsettling surrealism of Majora’s Mask. Will you retain your sanity long enough to halt the eldritch cataclysm, or become lost within Carnom’s fracturing nightmare?

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

_**UPDATES:**_

_**This portion of the documentation will keep tabs on new updates as I apply them.**_

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------                                                                            

_04/18/25_

_**0 - Basic Player Movement & Camera Control COMPLETED**_

_**Player Movement:**_

**1. Click to move & click & hold to move:**

Creates destination marker to where the player is moving to, and destroys it when the player has reached the location of the destination marker. You can click a destination or click and hold and move your mouse around to move around in different directions seemlessly.

**2. Camera Controls:**

1. A & D keys rotate the camera left and right respectively.
2. Left Arrow & Right Arrow keys rotate the camera left and right respectively.
3. W & S keys rotate the camera up and down respectively.
4. Up Arrow & Down Arrow keys rotate the camera up and down respectively.
5. Clicking & holding the mouse scroll button allows for full rotational control of the camera on all axis.
6. Scrolling the mouse wheel will zoom the camera in and out respectively.

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

_**Road Map:**_

_**This portion of the documentation will list out future tasks/ideas categorically in in a proper workflow manner.**_

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

**0 - Basic Player Movement & Camera Control**

**Goal:** Allow player charcter to walk around with click to move and click and hold to move controls. Camera orientation and rotational controls.

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

**1 - Block‑out a Play‑Test Zone**

**Goal:** Walk around a small slice of Carnom with some props and elevation changes.

**Task Tips:**
1. Create low‑poly terrain or modular floor tiles	Keep triangle counts tiny (≤ 2 000 tris per chunk).
2. Add a few props: trees, rocks, ruined arches, etc.	Group by material for instancing.
NavMesh rebake	Re‑bake any time I add walkable geometry.

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
