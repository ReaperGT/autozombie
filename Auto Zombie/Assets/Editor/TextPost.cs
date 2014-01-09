using UnityEngine;
using System.Collections;
using UnityEditor;

public class TextPost : AssetPostprocessor {

		void OnPreprocessTexture() {

			TextureImporter importer = (TextureImporter) assetImporter;
			importer.textureType = TextureImporterType.Advanced;
			//importer.textureFormat = TextureImporterFormat.PVRTC_RGBA4;
//			importer.textureFormat = TextureImporterFormat.AutomaticTruecolor;
			//importer.textureFormat = TextureImporterFormat.AutomaticCompressed;
			//importer.textureFormat = TextureImporterFormat.ARGB16;
			importer.npotScale  = TextureImporterNPOTScale.None;
			importer.maxTextureSize = 2048;
			importer.isReadable = true;
			importer.mipmapEnabled = false;
		}
}
