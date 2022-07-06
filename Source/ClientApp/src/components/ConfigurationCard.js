import * as React from "react"
import Card from "@mui/material/Card"
import CardActions from "@mui/material/CardActions"
import CardContent from "@mui/material/CardContent"
import ConfigurationSelect from "./ConfigurationSelect"

const ConfigurationCard = ({data, selected, label, handleChange}) => {
	return (
		<Card>
			<CardContent style={{padding: "2%"}}>
				These configurations were created during startup using a custom configuration provider called ApplicationConfigurationProvider which fetches configurations from a database. This class can be found under the Configurations directory. After the ApplicationConfigurationProvider populates IConfiguration with our custom configurations, we can then use the IOptions pattern to bind our dynamic app settings to our option models. These can then be fetched through normal dependency injection means like constructor injection.
			</CardContent>
			<CardActions style={{padding: "2%"}}>
                <ConfigurationSelect 
                    data={data} 
                    selected={selected}
                    label={label}
                    handleChange={handleChange}
                />
			</CardActions>
		</Card>
	)
}

export default ConfigurationCard