// const TIMEOUT = 1000

// const useTable = refresh => {

//     const onRowAdd = configuration => data => 
//         handleTimeout(handleBatch([...configuration, data]))

//     const onRowUpdate = configuration => (data, prevData) =>
//         handleTimeout((() => {
//             const temp = [...configuration]
//             temp[prevData.tableData.id] = data
//             return handleBatch(temp)
//         })())

//     const onRowDelete = configuration => data => 
//         handleTimeout((() => {
//             const temp = [...configuration]
//             temp.splice(data.tableData.id, 1)
//             return handleBatch(temp)
//         })())

//     const handleBatch = data => async (resolve, reject) => {
//         if (await batch(data)) {  
//             resolve(await refresh())
//         } else reject()
//     }

//     const handleTimeout = callback => 
//         new Promise((resolve, reject) => {
//             setTimeout(async () => await callback(resolve, reject), TIMEOUT);
//         })

//     return [onRowAdd, onRowUpdate, onRowDelete]
// }

// export default useTable