import React from 'react';
import useConfiguration from './hooks/useConfiguration';
import ConfigurationSelect from './components/ConfigurationSelect';

const App = () => {
	const [configuration, getConfiguration] = useConfiguration()

	const handleChange = event => {
		const { value } = event.target
		console.log(value)
	}

	return (
		<ConfigurationSelect handleChange={handleChange}/>
	)
}

export default App;
