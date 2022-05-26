import React, { useState, useEffect } from "react"
import ConfigurationSelect from "./ConfigurationSelect"
import ConfigurationTable from "./ConfigurationTable"
import useConfiguration from "../hooks/useConfiguration"
import useConfigurationTypes from "../hooks/useConfigurationTypes"
import ConfigurationCard from "./ConfigurationCard"

const Configuration = () => {
    const [configuration, getConfiguration] = useConfiguration()
	const [configurationType, setConfigurationType] = useState({id: -1})
    const [configurationTypes] = useConfigurationTypes()

	useEffect(() => 
        setConfigurationType({...configurationTypes[0]}), 
    [configurationTypes])

	const handleChange = async event => {
		const { value } = event.target;
		await getConfiguration(value)
		setConfigurationType({id: value})
	}

	return (
		<React.Fragment>
			<div style={{display: "flex"}}>
				<div style={{padding: "2.5%", width: "100%"}}>
					<ConfigurationCard 
						data={configurationTypes} 
						selected={configurationType}
						label="Configuration Type"
						handleChange={handleChange}
					/>
				</div>
				<div style={{padding: "2.5%", width: "100%"}}>
					<ConfigurationTable data={configuration}></ConfigurationTable>
				</div>
			</div>
		</React.Fragment>
	)
}

export default Configuration