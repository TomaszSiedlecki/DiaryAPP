import Navigation from "../components/navigation/navigation"

const Layout = (props:any) => {
    return(
        <>
            <Navigation/>
            {props.children}
        </>
    )
}
export default Layout;