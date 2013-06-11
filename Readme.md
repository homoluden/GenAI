Intro
=====
This is the basic hierarchical state machine based implementation of the AI which is controlled by gene values in its genome. State machine has three levels:  

 1.  Top level - Main goal (Feed, Attack, Retreat, Serve)  
 2.  Second level - Strategy (for ex., guerrilla/infantry/kamikaze for Attack Goal)  
 3.  Low level - Actions (for ex., chase/melee attack/ranged attack for infantry or guerrilla strategies) 

State machine used in this library are non-deterministic, i.e. machine transits to a random state respecting the transition weight and using the roulette wheel selection algorithm. The weights of transitions are controlled by genes in genome.
