import { Router } from "react-router-dom";
import { AuthProvider } from "../context/AuthContext";
import { DataProvider } from "../context/DataContext";

export function Providers({ children }) {
  return (
    <AuthProvider>
      <DataProvider>
        {children}
      </DataProvider>
    </AuthProvider>
  );
}
