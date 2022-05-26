import { Select, FormControl, MenuItem, InputLabel } from '@mui/material'

const ConfigurationSelect = ({data, selected, label, handleChange}) => {
    return (
        <FormControl fullWidth>
            <InputLabel>{label}</InputLabel>
            <Select
                value={selected.id}
                label={label}
                onChange={handleChange}
            >
                <MenuItem value={0}>
                    None
                </MenuItem>
                { 
                    data.map(configurationType =>
                        <MenuItem key={configurationType.id} value={configurationType.id}>
                            {configurationType.name}
                        </MenuItem>)
                }
            </Select>
        </FormControl>
    )
}

export default ConfigurationSelect