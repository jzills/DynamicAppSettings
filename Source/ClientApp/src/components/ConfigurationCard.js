import * as React from 'react';
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import ConfigurationSelect from "./ConfigurationSelect"

const ConfigurationCard = ({data, selected, label, handleChange}) => {
	return (
		<Card sx={{ minWidth: 500 }}>
			<CardContent>
                Content
			</CardContent>
			<CardActions>
                <ConfigurationSelect 
                    data={data} 
                    selected={selected}
                    label={label}
                    handleChange={handleChange}
                />
			</CardActions>
		</Card>
	);
}

export default ConfigurationCard