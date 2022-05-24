import { useEffect, useState } from "react"
import { getConfigurationTypes } from "../utilities/configuration"

const useConfigurationTypes = () => {
    const [configurationTypes, setConfigurationTypes] = useState([])

    useEffect(async () => 
        setConfigurationTypes([...await getConfigurationTypes()]), 
    [])

    return [configurationTypes]
}

export default useConfigurationTypes