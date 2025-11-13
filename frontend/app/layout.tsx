import type { Metadata } from 'next'
import './globals.css'

export const metadata: Metadata = {
  title: 'Property Listings',
  description: 'Find your dream property with our advanced search',
}

export default function RootLayout({
  children,
}: {
  children: React.ReactNode
}) {
  return (
    <html lang="en">
      <body>{children}</body>
    </html>
  )
}
