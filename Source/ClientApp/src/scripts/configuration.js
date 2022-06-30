const getConfiguration = async type => {
    const response = await fetch(`configuration/${type}`)
    return response.ok ? 
        response.json() : 
        console.error(`${response.status}: ${response.statusText}`)
}

const getConfigurationTypes = async () => {
    const response = await fetch(`configuration/types`)
    return response.ok ? 
        response.json() : 
        console.error(`${response.status}: ${response.statusText}`)
}

export { getConfiguration, getConfigurationTypes }