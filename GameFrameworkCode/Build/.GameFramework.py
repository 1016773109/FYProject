import shutil
import os
import sys
import subprocess
import platform

debugMode = ( sys.argv[1] == "Debug" ) or ( sys.argv[1] == "Debug_DirectReadMode")
targetPath = sys.argv[2] + "/"
targetName = sys.argv[3]
currentPath = os.path.split(os.path.realpath(__file__))[0] + "/"
isWin = False
if(platform.system() =="Windows"):
    isWin = True


resPath = currentPath + "/../../Project/Assets/GameFramework/Libraries/"

def mkdirs(path):
    path=path.strip()
    path=path.rstrip("\\")

    isExists=os.path.exists(path)

    if not isExists:
        os.makedirs(path)
        return True
    else:
        return False
mkdirs(resPath)

if debugMode:
    if isWin:

      shutil.copy(targetPath + targetName + ".pdb", resPath + targetName + ".pdb")
else:
	 if os.path.exists(resPath + targetName + ".pdb"):
	     os.remove(resPath + targetName + ".pdb")

	 
shutil.copy(targetPath + targetName + ".dll", resPath + targetName + ".dll")
