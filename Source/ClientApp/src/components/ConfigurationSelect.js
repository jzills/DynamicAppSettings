import { Select, FormControl, MenuItem, InputLabel } from '@mui/material';
import { useState, useEffect } from 'react';
import useConfigurationTypes from "../hooks/useConfigurationTypes"

const ConfigurationSelect = ({handleChange}) => {
    const [configurationType, setConfigurationType] = useState({id: -1})
    const [configurationTypes] = useConfigurationTypes()

    useEffect(() => 
        setConfigurationType({...configurationTypes[0]}), 
    [configurationTypes])
   
    return (
        <FormControl fullWidth>
            <InputLabel id="configuration-type-label">Configuration Type</InputLabel>
            <Select
                labelId="configuration-type-label"
                id="configuration-type-select"
                value={configurationType.id}
                label="Configuration Type"
                onChange={handleChange}
            >
                {
                    configurationTypes.map(configurationType =>
                        <MenuItem 
                            key={configurationType.id} 
                            value={configurationType.id}
                        >
                            {configurationType.name}
                        </MenuItem>
                    )
                }
            </Select>
        </FormControl>
    )
}

export default ConfigurationSelect