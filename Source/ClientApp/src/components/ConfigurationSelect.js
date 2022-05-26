import { Select, FormControl, MenuItem, InputLabel } from '@mui/material'

const ConfigurationSelect = ({data, selected, label, handleChange}) => {
    return (
        <FormControl fullWidth>
            <InputLabel id="configuration-type-label">{label}</InputLabel>
            <Select
                labelId="configuration-type-label"
                id="configuration-type-select"
                value={selected.id}
                label={label}
                onChange={handleChange}
            >
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