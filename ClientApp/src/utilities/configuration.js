const configurationTypes = Object.freeze({
    I_CONFIGURATION: 0,
    SMTP_OPTIONS: 1,
    API_OPTIONS: 2,
    API_OTHER_OPTIONS: 3
})

const getConfiguration = async type => {
    const response = await fetch(`configuration/get?type=${type}`)
    if (response.ok) {
        return response.json()
    } else {
        console.error(`${response.status}: ${response.statusText}`)
    }
}

export { configurationTypes, getConfiguration }