# EnemiesHierarchy
Collection of scripts that use multiple inheritance to eliminate duplicate code.

Hierarchy start with EnemiesBase.

Scripts that inherit EnemiesBase are as follows: 
                                      HeavyMovement
                                      KamikazeMovement
                                      LightMovement
                                      MineBase
                                      TurretTracking

Each bottom level script inherits from the mid level, or movement, scripts.
The bottom level scripts are as follows:
                                  BasicMine
                                  HeavyBeamFrigate
                                  HeavyBurst
                                  Kamikaze
                                  LightOneShot
                                  SmOneShotTurret
