# Architectures Landscape
Please find assessment details here: [Assessment](https://docs.google.com/document/d/1G3y16cTEYC__xfKTnoHP3YrW0FQSRB2kf8S23i1Gg8M/edit?tab=t.0#heading=h.5uoc4mfz7mn4).

Extend Windows Path
```POWERSHELL
New-ItemProperty -Path "HKLM:\SYSTEM\CurrentControlSet\Control\FileSystem" -Name "LongPathsEnabled" -Value 1 -PropertyType DWORD -Force
```
