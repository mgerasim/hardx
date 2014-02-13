@echo off

call git add . 
call git commit -m fix 
call git push origin master


cd X:\HardX\src\HardX.git\
call X:\HardX\src\HardX.git\push_remote.bat

echo Выполнено