import Head from "next/head";
import Image from "next/image";
import { Geist, Geist_Mono } from "next/font/google";
import styles from "@/styles/Home.module.css";

const geistSans = Geist({
  variable: "--font-geist-sans",
  subsets: ["latin"],
});

const geistMono = Geist_Mono({
  variable: "--font-geist-mono",
  subsets: ["latin"],
});

export default function Home() {
  return (
    <>
      <Head>
        <title>Mirrack Smarter Mirror</title>
        <meta name="description" content="A smart mirror platform that uses an arduino serial connection to transform old laptops to an interactive smart mirror with buttons and voice controls" />
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <link rel="icon" href="/favicon.ico" />
      </Head>
      <div style={{paddingLeft: 300, paddingRight:300, paddingTop:100}}>
      <h1 style={{textAlign:"center"}}>Mirrack: The Interactive Open-Source Smart Mirror</h1>
      <br/>
      <p>
        The name <strong>Mirrack</strong> is a combination of the words <strong>mirror</strong> and <strong>hack</strong> and represents taking back control of your old devices and making them into something not only useful again, but something you love to use.
      </p>
      <br/>

      <p>
        This open-source smart mirror project is designed specifically for low-power laptops, and made to be as easy to set up as possible. Built with C# and Avalonia, Mirrack features a clean, modular interface that displays useful daily information like calendars, to-do lists, alarms, and weather. Mirrack uses Arduino buttons and Vosk for offline voice commands to interact with the device, allowing you to control the device rather than having a static display.
      </p>
      <br/>
      <p>
        The project includes a custom Arch Linux ISO for a hassle-free, keyboard-free setup, allowing users to turn an outdated device into an interactive home assistant with minimal effort and cost.
      </p>
      <br/>
      <div>
        <strong>🚧 This Project is under development and is not yet complete. 🚧</strong><br/>
        Stay tuned for updates on the project! It is currently scheduled to have a full version on <strong>8/12/25</strong>.
      </div>
      <br/>
      <p>
        If you are interested in buying a kit or supporting the project, email me at <a href="mailto:contact@mirrack.xyz">contact@mirrack.xyz</a>. Have any more questions about this project? feel free to reach out!
      </p>
      <br/>
      <h3>Features</h3>
      <ul>
        <li>🌟 Interactivity! (control mirror with buttons and voice)</li>
        <li>📆 Google Calendar integration (view, add, edit events)</li>
        <li>⏰ Alarms and timers</li>
        <li>🌤 Live weather display</li>
        <li>✅ To-do list</li>
        <li>🔧 Arduino-powered physical controls</li>
        <li>💾 Firebase sync for user preferences</li>
        <li>💿 Plug-and-play ISO installer</li>
      </ul>
      <br/>
      <h3>Why?</h3>
      <p>
        Too many cloud-based laptops end up as e-waste. Mirrack aims to give them a second life as useful, minimalist smart displays — with a simple, low-cost setup anyone can build.
      </p>
      <br/>
      <p><strong>Get started, contribute, or build your own.</strong><br/>
      Visit <a href="https://github.com/LillyLaFrog/mirrack">https://github.com/LillyLaFrog/mirrack</a> for the source code</p>
      <br/>
      <div class="footer">
        Happy Hacking!<br/>
        <strong>Mirrack 2025</strong>
      </div>
    </div>
    </>
  );
}
