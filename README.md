# VRStuff
Some scripts used for VR projects 

 GunController.cs   a script that allows a gun to be fired with the HTC Vive controller in unity projects 
requires the SteamVR SDK imported in your project. 

CubeRotate.cs   A script to make an object rotate based on vector3 translate.  Has some public variables so you can change it in the unity editor

EnemyHealth.cs   Modded the EnemeyHealth from the survival shooter to react to a hammer object.  When you hit the enemy with the hammer it is stunted or like smooshed by the hammer then it dies, removes the sinking ability so it just lies there then dissapears.   (need an object tagged "Hammer" to work.) 


Hammer.cs  handles the hammer has public variables for sound, and a particle affect.  Can easily be modded for a sword or some other hand object.   Also has a public variable for a hand game object to track the controller 
