timeout /t 3 /nobreak > NUL

set ProjektName=SpecFlowProject1.dll

livingdoc test-assembly %ProjektName% -t TestExecution.json

