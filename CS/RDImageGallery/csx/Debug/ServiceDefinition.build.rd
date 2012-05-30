<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="RDImageGallery" generation="1" functional="0" release="0" Id="639120e9-8c63-458a-92b4-9d570abafe5e" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="RDImageGalleryGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="RDImageGallery_WebRole:HttpIn" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/RDImageGallery/RDImageGalleryGroup/LB:RDImageGallery_WebRole:HttpIn" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="RDImageGallery_WebRole:ContainerName" defaultValue="">
          <maps>
            <mapMoniker name="/RDImageGallery/RDImageGalleryGroup/MapRDImageGallery_WebRole:ContainerName" />
          </maps>
        </aCS>
        <aCS name="RDImageGallery_WebRole:DataConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/RDImageGallery/RDImageGalleryGroup/MapRDImageGallery_WebRole:DataConnectionString" />
          </maps>
        </aCS>
        <aCS name="RDImageGallery_WebRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/RDImageGallery/RDImageGalleryGroup/MapRDImageGallery_WebRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="RDImageGallery_WebRoleInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/RDImageGallery/RDImageGalleryGroup/MapRDImageGallery_WebRoleInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:RDImageGallery_WebRole:HttpIn">
          <toPorts>
            <inPortMoniker name="/RDImageGallery/RDImageGalleryGroup/RDImageGallery_WebRole/HttpIn" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapRDImageGallery_WebRole:ContainerName" kind="Identity">
          <setting>
            <aCSMoniker name="/RDImageGallery/RDImageGalleryGroup/RDImageGallery_WebRole/ContainerName" />
          </setting>
        </map>
        <map name="MapRDImageGallery_WebRole:DataConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/RDImageGallery/RDImageGalleryGroup/RDImageGallery_WebRole/DataConnectionString" />
          </setting>
        </map>
        <map name="MapRDImageGallery_WebRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/RDImageGallery/RDImageGalleryGroup/RDImageGallery_WebRole/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapRDImageGallery_WebRoleInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/RDImageGallery/RDImageGalleryGroup/RDImageGallery_WebRoleInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="RDImageGallery_WebRole" generation="1" functional="0" release="0" software="D:\Enterprise Repo\CS\RDImageGallery\csx\Debug\roles\RDImageGallery_WebRole" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="HttpIn" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="ContainerName" defaultValue="" />
              <aCS name="DataConnectionString" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;RDImageGallery_WebRole&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;RDImageGallery_WebRole&quot;&gt;&lt;e name=&quot;HttpIn&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/RDImageGallery/RDImageGalleryGroup/RDImageGallery_WebRoleInstances" />
            <sCSPolicyFaultDomainMoniker name="/RDImageGallery/RDImageGalleryGroup/RDImageGallery_WebRoleFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyFaultDomain name="RDImageGallery_WebRoleFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="RDImageGallery_WebRoleInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="fdcba25c-7a6d-4057-bd81-624a508101cf" ref="Microsoft.RedDog.Contract\ServiceContract\RDImageGalleryContract@ServiceDefinition.build">
      <interfacereferences>
        <interfaceReference Id="416f3955-9d81-4017-ba26-f25ff5379df7" ref="Microsoft.RedDog.Contract\Interface\RDImageGallery_WebRole:HttpIn@ServiceDefinition.build">
          <inPort>
            <inPortMoniker name="/RDImageGallery/RDImageGalleryGroup/RDImageGallery_WebRole:HttpIn" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>