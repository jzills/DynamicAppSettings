import React from "react"
import ConfigurationSelect from "./ConfigurationSelect"
import ConfigurationTable from "./ConfigurationTable"
import useConfiguration from "../hooks/useConfiguration"

const Configuration = () => {
    const [configuration, getConfiguration] = useConfiguration()
    
	const handleChange = event => getConfiguration(event.target.value)

	return (
		<React.Fragment>
			<ConfigurationSelect handleChange={handleChange}/>
			<ConfigurationTable data={configuration}></ConfigurationTable>
        </React.Fragment>
	)
}

export default Configuration