import React, { useState } from "react"
import ConfigurationTable from "./ConfigurationTable"
import useConfiguration from "../hooks/useConfiguration"
import useConfigurationTypes from "../hooks/useConfigurationTypes"
import ConfigurationCard from "./ConfigurationCard"

const Configuration = () => {
    const [configuration, getConfiguration] = useConfiguration()
	const [configurationType, setConfigurationType] = useState({id: 0})
    const [configurationTypes] = useConfigurationTypes()

	const handleChange = async event => {
		const { value } = event.target;
		await getConfiguration(value)
		setConfigurationType({id: value})
	}

	return (
		<React.Fragment>
			<div style={{padding: "2%", paddingBottom: "0", width: "100%"}}>
				<ConfigurationCard 
					data={configurationTypes} 
					selected={configurationType}
					label="Configuration Type"
					handleChange={handleChange}
				/>
			</div>
			{
				!!configurationType.id && 
					<div style={{padding: "2%", width: "100%"}}>
						<ConfigurationTable data={configuration}></ConfigurationTable>
					</div>
			}
		</React.Fragment>
	)
}

export default Configuration