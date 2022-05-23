import React from 'react';
import useConfiguration from './hooks/useConfiguration';
import { configurationTypes } from './utilities/configuration';

const App = () => {
	const [configuration, getConfiguration] = useConfiguration(configurationTypes.SMTP_OPTIONS)

	return (
		<React.Fragment>
			{
				Object.keys(configuration).map(key => <div>{key}</div>)
			}
			<button onClick={() => getConfiguration(configurationTypes.API_OPTIONS)}>click</button>
		</React.Fragment>
	)
}

export default App;
