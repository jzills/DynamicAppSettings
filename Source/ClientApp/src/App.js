import React from "react"
import useConfiguration from "./hooks/useConfiguration"
import ConfigurationSelect from "./components/ConfigurationSelect"
import ConfigurationTable from "./components/ConfigurationTable"

const App = () => {
	const [configuration, getConfiguration] = useConfiguration()

	const handleChange = event => getConfiguration(event.target.value)

	return (
		<React.Fragment>
			<ConfigurationSelect handleChange={handleChange}/>
			<ConfigurationTable data={configuration}></ConfigurationTable>
		</React.Fragment>
	)
}

export default App;
