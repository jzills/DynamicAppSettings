import { useState, useEffect } from "react"
import { getConfiguration } from "../utilities/configuration"

const useConfiguration = defaultConfigType => {
    const [configuration, setConfiguration] = useState([])

    useEffect(async () => 
        setConfiguration([...await getConfiguration(defaultConfigType)]), 
    [])

    return [
        configuration, 
        async configurationType => 
            setConfiguration([...await getConfiguration(configurationType)])
    ]
}

export default useConfiguration