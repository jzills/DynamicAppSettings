import * as React from "react"
import Card from "@mui/material/Card"
import CardActions from "@mui/material/CardActions"
import CardContent from "@mui/material/CardContent"
import ConfigurationSelect from "./ConfigurationSelect"

const ConfigurationCard = ({data, selected, label, handleChange}) => {
	return (
		<Card>
			<CardContent style={{padding: "2%"}}>
			Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
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