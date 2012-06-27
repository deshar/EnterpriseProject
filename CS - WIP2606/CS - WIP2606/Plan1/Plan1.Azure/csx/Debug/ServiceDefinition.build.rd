<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="Plan1.Azure" generation="1" functional="0" release="0" Id="89e2799a-0406-4e22-aa5d-1d54ecd1d5f2" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="Plan1.AzureGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="Plan1:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/Plan1.Azure/Plan1.AzureGroup/LB:Plan1:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="Plan1:BlobConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/Plan1.Azure/Plan1.AzureGroup/MapPlan1:BlobConnectionString" />
          </maps>
        </aCS>
        <aCS name="Plan1:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/Plan1.Azure/Plan1.AzureGroup/MapPlan1:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="Plan1Instances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/Plan1.Azure/Plan1.AzureGroup/MapPlan1Instances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:Plan1:Endpoint1">
          <toPorts>
            <inPortMoniker name="/Plan1.Azure/Plan1.AzureGroup/Plan1/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapPlan1:BlobConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/Plan1.Azure/Plan1.AzureGroup/Plan1/BlobConnectionString" />
          </setting>
        </map>
        <map name="MapPlan1:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/Plan1.Azure/Plan1.AzureGroup/Plan1/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapPlan1Instances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/Plan1.Azure/Plan1.AzureGroup/Plan1Instances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="Plan1" generation="1" functional="0" release="0" software="D:\EnterpriseRepo\CS - WIP2606\Plan1\Plan1.Azure\csx\Debug\roles\Plan1" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="BlobConnectionString" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;Plan1&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;Plan1&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/Plan1.Azure/Plan1.AzureGroup/Plan1Instances" />
            <sCSPolicyFaultDomainMoniker name="/Plan1.Azure/Plan1.AzureGroup/Plan1FaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyFaultDomain name="Plan1FaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="Plan1Instances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="9c04e1fc-ce48-4fe4-8d26-322091f0183c" ref="Microsoft.RedDog.Contract\ServiceContract\Plan1.AzureContract@ServiceDefinition.build">
      <interfacereferences>
        <interfaceReference Id="f05e4846-bdf4-4d18-8ad6-16c4c509ae5f" ref="Microsoft.RedDog.Contract\Interface\Plan1:Endpoint1@ServiceDefinition.build">
          <inPort>
            <inPortMoniker name="/Plan1.Azure/Plan1.AzureGroup/Plan1:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>